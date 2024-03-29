﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data;

public class Circle : INotifyPropertyChanged
{
    private double _x;
    private double _y;
    private double _r;
    private double _velX;
    private double _velY;
    private double _mass;
    private string? _color;
    private int _id;

    public Circle(double x, double y, double r, double mass)
    {
        _x = x;
        _y = y;
        _r = r;
        _mass = mass;
    }

    public Circle(double x, double y, double mass)
    {
        _x = x;
        _y = y;
        _mass = mass;
        _r = mass * 20;
    }
    
    public Circle(double x, double y, double r, double mass, int id)
    {
        _x = x;
        _y = y;
        _r = r;
        _mass = mass;
        _id = id;
    }
    
    public int Id
    {
        get => _id;
        set => _id = value;
    }
    
    public string? Color
    {
        get => _color;
        set => _color = value;
    }
    
    public double X
    {
        get => _x;
        set
        {
            _x = value;
            OnPropertyChanged("x");
        }
    }
    
    public double Y
    {
        get => _y;
        set
        {
            _y = value;
            OnPropertyChanged("y");
        }
    }
    
    public double R
    {
        get => _r;
        set => _r = value;
    }

    public double Mass
    {
        get => _mass;
        set => _mass = value;
    }
    
    public double VelX
    {
        get => _velX;
        set => _velX = value;
    }
    
    public double VelY
    {
        get => _velY;
        set => _velY = value;
    }
    
    public void Move()
    {
        X += VelX;
        Y += VelY;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}