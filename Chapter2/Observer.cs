using System;
using System.Collections.Generic;

namespace Chapter2
{
    public interface IObserver
    {
        void Update(float temprature, float humidity, float preasure);
    }

    public interface IPublisher
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Brodcast();
    }

    public interface IDisplay
    {
        void display();
    }

    public class WeatherPublisher : IPublisher
    {
        private List<IObserver> _observers = new List<IObserver>();
        private float _temperatrue, _humidity, _preasure;
        public void Brodcast()
        {
            foreach (var item in _observers)
            {
                item.Update(_temperatrue, _humidity, _preasure);
            }
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        private void MeasurementsChanged()
        {
            Brodcast();
        }

        public void GetMeasurments(float temperature, float humidity, float preasure)
        {
            _temperatrue = temperature;
            _preasure = preasure;
            _humidity = humidity;
            MeasurementsChanged();
        }
    }

    public class MyWeatherDisplay : IDisplay, IObserver
    {
        private IPublisher _publisher;
        private float _temperature;
        private float _preasure;
        private float _humidity;

        public MyWeatherDisplay(IPublisher publisher)
        {
            _publisher = publisher;
            _publisher.Subscribe(this);
        }

        public void display()
        {
            Console.WriteLine($"MyWeatherDisplay is deisplaying temperature = {_temperature} , preasure = {_preasure} and humidity = {_humidity}");
        }

        public void Update(float temprature, float humidity, float preasure)
        {
            _temperature = temprature;
            _humidity = humidity;
            _preasure = preasure;
            display();
        }
    }

    public class TestObserver
    {
        public static void Test()
        {
            var weatherPublisher = new WeatherPublisher();
            var observer = new MyWeatherDisplay(weatherPublisher);
            weatherPublisher.GetMeasurments(1, 2, 3);
        }
    }
}
