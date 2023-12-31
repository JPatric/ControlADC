using System;

public partial class MainPag : Form
{
    private List<SKPoint> chartPoints;
    private bool receivingData = false;
    private double gain = 1.0;
    private IBluetoothLE bluetoothLE;
    private IAdapter adapter;
    private IDevice selectedDevice;
    private bool isDeviceSelected = false;
    public MainPag()
    {
        InitializeComponent();
        chartPoints = new List<SKPoint>(); // Lista para almacenar los puntos de la gráfica
        bluetoothLE = CrossBluetoothLE.Current;
        adapter = CrossBluetoothLE.Current.Adapter;
    }

    private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        // Dibuja la gráfica utilizando SkiaSharp
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;
        canvas.Clear();

        float chartWidth = args.Info.Width - 40;
        float chartHeight = args.Info.Height - 40;

        // Definir la posición y tamaño de la gráfica
        SKRect chartRect = new SKRect(20, 20, 20 + chartWidth, 20 + chartHeight);

        using (SKPaint paint = new SKPaint())
        {
            // Establecer el color de fondo del gráfico
            paint.Color = SKColors.White;
            canvas.DrawRect(chartRect, paint);

            // Dibujar la línea y los puntos de la gráfica
            if (chartPoints.Count > 1)
            {
                paint.Color = SKColors.Magenta;
                paint.StrokeWidth = 2;
                paint.IsAntialias = true;
                paint.StrokeCap = SKStrokeCap.Round;

                float xStep = chartWidth / (chartPoints.Count - 1);
                float x = 20;
                float y = 20 + chartHeight - (chartHeight * chartPoints[0].Y / 100); // Reemplaza "100" con el rango máximo de tus datos

                for (int i = 1; i < chartPoints.Count; i++)
                {
                    float nextY = 20 + chartHeight - (chartHeight * chartPoints[i].Y / 100); // Reemplaza "100" con el rango máximo de tus datos
                    canvas.DrawLine(x, y, x + xStep, nextY, paint);
                    canvas.DrawCircle(x, y, 5, paint);
                    x += xStep;
                    y = nextY;
                }
            }
        }
    }

    private void UpdateChart()
    {
        canvasView.InvalidateSurface(); // Redibujar la gráfica en la SKCanvasView
    }

    private void AddChartData(float dataPoint)
    {
        // Agregar un nuevo punto de datos a la gráfica
        chartPoints.Add(new SKPoint(chartPoints.Count, dataPoint));

        // Limitar el número de puntos en la gráfica a, por ejemplo, los últimos 10 puntos
        if (chartPoints.Count > 10)
        {
            chartPoints.RemoveAt(0);
        }

        // Actualizar la gráfica
        UpdateChart();
    }

    // Llamada a AddChartData() cuando lleguen nuevos valores de datos
    // Por ejemplo, si recibes datos a través de Bluetooth, puedes llamar a esta función cuando llegue un nuevo valor
    private void NewDataReceived(float newData)
    {
        Device.BeginInvokeOnMainThread(() =>
        {
            // Aplicar la ganancia al valor de voltaje recibido.
            newData *= (float)gain;

            if (receivingData)
            {
                AddChartData(newData);
            }
        });
    }




    private async Task<List<IDevice>> GetPairedDevices()
    {
        // Obtener la lista de dispositivos Bluetooth emparejados o conectados en el sistema.
        var devices = adapter.GetSystemConnectedOrPairedDevices();
        var pairedDevices = devices.ToList();
        return pairedDevices;
    }

    private async void ButtonConnect_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Obtener la lista de dispositivos Bluetooth emparejados o conectados en el sistema.
            var devices = await GetPairedDevices();

            if (devices.Count > 0)
            {
                // Aquí, podemos mostrar una hoja de acción que contiene los nombres de los dispositivos emparejados disponibles para que el usuario seleccione.
                List<string> deviceNames = new List<string>();
                foreach (var device in devices)
                {
                    deviceNames.Add(device.Name);
                }

                string selectedDeviceName = await DisplayActionSheet("Seleccionar dispositivo Bluetooth", "Cancelar", null, deviceNames.ToArray());

                if (!string.IsNullOrEmpty(selectedDeviceName) && selectedDeviceName != "Cancelar")
                {
                    selectedDevice = devices.FirstOrDefault(d => d.Name == selectedDeviceName);
                    if (selectedDevice != null)
                    {
                        isDeviceSelected = true;
                        // Simulamos recibir datos cada segundo para actualizar la gráfica
                        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                        {
                            float newData = (float)new Random().NextDouble() * 100; // Datos aleatorios (reemplaza con tus datos reales)
                            NewDataReceived(newData);
                            return true;
                        });

                        btnConnect.IsEnabled = false; // Deshabilitar el botón "Conectar Bluetooth" después de la conexión exitosa.
                    }
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "No se encontraron dispositivos Bluetooth emparejados.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al buscar dispositivos Bluetooth: " + ex.Message, "OK");
        }
    }



    private void ButtonLoad_Clicked(object sender, EventArgs e)
    {
        // Botón "Cargar Datos" pulsado, establecer receivingData en true para recibir datos.
        receivingData = true;
    }

    private void ButtonStop_Clicked(object sender, EventArgs e)
    {
        // Botón "Detener Recepción" pulsado, establecer receivingData en false para detener la recepción de datos.
        receivingData = false;
    }

    private async void ButtonSave_Clicked(object sender, EventArgs e)
    {
        // Botón "Guardar Datos" pulsado, guardar los datos recibidos en un archivo de texto.
        string fileName = "datos_amplitud_voltaje.txt";
        string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

        try
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
            {
                foreach (var dataPoint in chartPoints)
                {
                    writer.WriteLine(dataPoint.Y.ToString());
                }
            }

            await DisplayAlert("Éxito", "Los datos se han guardado correctamente en " + filePath, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al guardar los datos: " + ex.Message, "OK");
        }
    }

    private async void ButtonModifyGain_Clicked(object sender, EventArgs e)
    {
        // Botón "Modificar Ganancia" pulsado, mostrar un cuadro de diálogo o una página de configuración para ajustar la ganancia.

        // Puedes utilizar un cuadro de diálogo para ingresar un nuevo valor de ganancia.
        string newGainString = await DisplayPromptAsync("Modificar Ganancia", "Introduce el nuevo valor de ganancia:", initialValue: gain.ToString());
        if (float.TryParse(newGainString, out float newGain))
        {
            // Actualizar el valor de ganancia con el nuevo valor ingresado por el usuario.
            gain = newGain;
        }
    }
}