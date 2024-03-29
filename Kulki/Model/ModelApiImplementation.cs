﻿using System.Collections.ObjectModel;
using Logic;
using Data;

namespace Model;

public class ModelApiImplementation : ModelApi
{
    private LogicApi _logicApi;
    private ObservableCollection<Circle> _movingCircles = new();
    public List<string?> Colors = new() {"red", "blue", "green", "yellow", "black", "orange", "purple", "brown"};

    public ModelApiImplementation(LogicApi logicApi)
    {
        _logicApi = logicApi;
    }

    public override void Update()
    {
        _logicApi.Update();
    }

    public override ObservableCollection<Circle> GetBalls()
    {
        return _movingCircles;
    }
    
    public override void Generate(int count)
    {
        _logicApi.SetLoggerPath("log.xml");
        _logicApi.AddCircles(count);
        List<Circle> list = _logicApi.GetCircles();
        for (int i = 0; i < count; i++)
        {
            list[i].Color = Colors[i % Colors.Count];
            _movingCircles.Add(list[i]);
        }
    }
    
    public override void AddCircle(Circle circle)
    {
        _logicApi.AddCircle(circle);
        _movingCircles.Add(circle);
    }
    
    public override void Reset()
    {
        _movingCircles.Clear();
        _logicApi.Reset();
    }
    
    public override double GetCanvasWidth()
    {
        return _logicApi.GetCanvasWidth();
    }
    
    public override double GetCanvasHeight()
    {
        return _logicApi.GetCanvasHeight();
    }
    
    public override void Stop()
    {
        _logicApi.Cancellation.Cancel();
        _logicApi.Stop();
    }
    
    public override void Start()
    {
        _logicApi.Cancellation = new();
        _logicApi.Start();
    }
    
    public override void SetLoggerPath(string path)
    {
        _logicApi.SetLoggerPath(path);
    }
}