using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Data;
using Logic;
using Model;


namespace ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    private ModelApi ModelApi;
    public ObservableCollection<Ball> Balls { get; set; }
    private string _numOfBalls;
    private double _canvasWidth;
    private double _canvasHeight;
    private bool _enable = true;

    public ICommand GenerateCommand { get; }
    public ICommand ResetCommand { get; }
    public ICommand StartCommand { get; }
    public ICommand StopCommand { get; }

    public MainViewModel()
    {
        ModelApi = ModelApi.Create(LogicApi.Create());
        CanvasWidth = ModelApi.GetCanvasWidth();
        CanvasHeight = ModelApi.GetCanvasHeight();
        GenerateCommand = new RelayCommand(o => GenerateBalls(), o => true);
        ResetCommand = new RelayCommand(o => ResetBalls(), o => true);
        StartCommand = new RelayCommand(o => Start(), o => true);
        StopCommand = new RelayCommand(o => Stop(), o => true);
        Balls = ModelApi.GetBalls();
    }
    
    public double CanvasWidth
    {
        get => _canvasWidth;
        set => SetField(ref _canvasWidth, value);
    }
    
    public double CanvasHeight
    {
        get => _canvasHeight;
        set => SetField(ref _canvasHeight, value);
    }
    
    public bool Enable
    {
        get => _enable;
        set => SetField(ref _enable, value);
    }
    
    public string NumOfBalls
    {
        get => _numOfBalls;
        set => SetField(ref _numOfBalls, value);
    }

    private void GenerateBalls()
    {
        ModelApi.Generate(Int32.Parse(NumOfBalls));
        Enable = false;
    }
    
    private void ResetBalls()
    {
        ModelApi.Reset();
        Enable = true;
        NumOfBalls = "";
    }
    
    private void Start()
    {
        
    }
    
    private void Stop()
    {
        
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