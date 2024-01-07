using ConfigurationReader.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace ConfigurationReader
{
    public class ConfigReader
    {
        private string _applicationName { get; set; }
        private string _connectionString { get; set; }
        private long _refreshTimerIntervalInMs { get; set; }
        private Timer timer { get; set; }

        private List<Configuration> _configurations = new List<Configuration>();

        public ConfigReader(string applicationName, string connectionString, long refreshTimerIntervalInMs)
        {
            _applicationName = applicationName;
            _connectionString = connectionString;
            _refreshTimerIntervalInMs = refreshTimerIntervalInMs;
            RefreshConfigListForTimer();
            SetTimer();
        }

        public T GetValue<T>(string name)
        {
            var confItem = _configurations.FirstOrDefault(p => p.Name == name);  
            if (confItem != null)
            {
                if (typeof(T) == typeof(bool))
                {
                    return (T)(object)(confItem.Value == "1");

                }
                return (T)Convert.ChangeType(confItem.Value, typeof(T));
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        //timer setleyip periyodik olarak güncelleme
        private void SetTimer()
        {
            timer = new Timer();
            timer.Interval = _refreshTimerIntervalInMs;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.AutoReset = true;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RefreshConfigListForTimer();
        }
        private void RefreshConfigListForTimer()
        {
            try
            {
                using (var context = new ConfigurationDbContext(_connectionString))
                {
                    _configurations = context.ConfigurationModels
                        .Where(p => p.IsActive == 1 && p.ApplicationName == _applicationName)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
