using System.Xml.Serialization;
using Data;

public class Logger
{
    private string _logFilePath;
    private Dictionary<int, CircleData> _circleDataMap;

    public Logger(string logFilePath)
    {
        _logFilePath = logFilePath;
        _circleDataMap = new Dictionary<int, CircleData>();
        LoadLogData();
    }

    public void LogDiagnosticData(Circle circle)
    {
        if (_circleDataMap.TryGetValue(circle.Id, out var existingCircleData))
        {
            existingCircleData.Timestamp = DateTime.Now;
            existingCircleData.Description = $"Kulka o promieniu {circle.R} została przeniesiona na Canvas. Jej współrzędne to:" +
                                             $" ({circle.X}, {circle.Y}). Masa kulki wynosi: {circle.Mass}.";
            existingCircleData.Radius = circle.R;
            existingCircleData.XCoordinate = circle.X;
            existingCircleData.YCoordinate = circle.Y;
            existingCircleData.Mass = circle.Mass;
            existingCircleData.VelocityX = circle.VelX;
            existingCircleData.VelocityY = circle.VelY;
            existingCircleData.Color = circle.Color;
        }
        else
        {
            CircleData newCircleData = new CircleData
            {
                Id = circle.Id,
                Event = "Kulka nr " + circle.Id,
                Timestamp = DateTime.Now,
                Description = $"Kulka o promieniu {circle.R} została dodana do Canvas. Jej współrzędne to:" +
                              $" ({circle.X}, {circle.Y}) Masa kulki wynosi: {circle.Mass}.",
                Radius = circle.R,
                XCoordinate = circle.X,
                YCoordinate = circle.Y,
                Mass = circle.Mass,
                VelocityX = circle.VelX,
                VelocityY = circle.VelY,
                Color = circle.Color
            };
            _circleDataMap.Add(circle.Id, newCircleData);
        }
        SaveLogData();
    }


    private void LoadLogData()
    {
        if (File.Exists(_logFilePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CircleData>));
            using (StreamReader reader = new StreamReader(_logFilePath))
            {
                List<CircleData> circleDataList = (List<CircleData>)serializer.Deserialize(reader);
                _circleDataMap.Clear();
                if (circleDataList != null)
                    foreach (CircleData circleData in circleDataList)
                    {
                        _circleDataMap.TryAdd(circleData.Id, circleData);
                    }
            }
        }
    }

    private void SaveLogData()
    {
        List<CircleData> circleDataList = new List<CircleData>(_circleDataMap.Values);
        XmlSerializer serializer = new XmlSerializer(typeof(List<CircleData>));
        using (StreamWriter writer = new StreamWriter(_logFilePath))
        {
            serializer.Serialize(writer, circleDataList);
        }
    }
}

public class CircleData
{
    public string? Event { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Description { get; set; }
    public double Radius { get; set; }
    public double XCoordinate { get; set; }
    public double YCoordinate { get; set; }
    public double Mass { get; set; }
    public double VelocityX { get; set; }
    public double VelocityY { get; set; }
    public string? Color { get; set; }
    public int Id { get; set; }
}