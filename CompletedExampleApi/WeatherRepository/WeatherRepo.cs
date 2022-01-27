using WeatherDefinition;
using WeatherRepository.Mappers;
using DbWeatherCondition = WeatherDefinition.WeatherCondition;
using WeatherCondition = WeatherDomain.WeatherCondition;

namespace WeatherRepository
{
    public class WeatherRepo
    {
        public List<WeatherCondition> GetAllWeatherConditions()
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    using (var transaction = dbContext.Database.BeginTransaction())
                    {
                        List<WeatherCondition> weatherConditions = null;

                        var dbWeatherConditions = dbContext.WeatherConditions
                            .ToList();

                        transaction.Commit();

                        weatherConditions = WeatherConditionMapper.Map(dbWeatherConditions);

                        return weatherConditions;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public WeatherCondition GetWeatherCondition(int id)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    using (var transaction = dbContext.Database.BeginTransaction())
                    {
                        WeatherCondition weatherCondition = null;

                        var dbWeatherCondition = dbContext.WeatherConditions
                            .Where(wc => wc.Id == id)
                            .FirstOrDefault();

                        transaction.Commit();

                        if (dbWeatherCondition != null)
                        {
                            weatherCondition = WeatherConditionMapper.Map(dbWeatherCondition);
                        }

                        return weatherCondition;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public WeatherCondition CreateWeatherCondition(WeatherCondition weatherCondition)
        {
            try
            {
                var dbWeatherCondition = BuildDbWeatherCondition(weatherCondition);

                using (var dbContext = new DatabaseContext())
                {
                    dbContext.Add(dbWeatherCondition);
                    dbContext.SaveChanges();

                    var returnedWeatherCondition = WeatherConditionMapper.Map(dbWeatherCondition);

                    return returnedWeatherCondition;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public WeatherCondition UpdateWeatherCondition(WeatherCondition weatherCondition)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    using (var transaction = dbContext.Database.BeginTransaction())
                    {
                        WeatherCondition returnedWeatherCondition = null;

                        var dbWeatherCondition = dbContext.WeatherConditions
                            .Where(wc => wc.Id == weatherCondition.Id)
                            .FirstOrDefault();
                        
                        if (dbWeatherCondition != null)
                        {
                            dbWeatherCondition.Condition = weatherCondition.Summary;
                            dbWeatherCondition.TemperatureF = weatherCondition.TemperatureF;
                            
                            dbContext.Update(dbWeatherCondition);
                            dbContext.SaveChanges();

                            returnedWeatherCondition = WeatherConditionMapper.Map(dbWeatherCondition);
                        }

                        transaction.Commit();
                        return returnedWeatherCondition;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteWeatherCondition(int id)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    using (var transaction = dbContext.Database.BeginTransaction())
                    {
                        var dbWeatherCondition = dbContext.WeatherConditions
                            .Where(wc => wc.Id == id)
                            .FirstOrDefault();

                        if (dbWeatherCondition != null)
                        {
                            dbContext.Remove(dbWeatherCondition);
                            dbContext.SaveChanges();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DbWeatherCondition BuildDbWeatherCondition(WeatherCondition weatherCondition)
        {
            var dbWeatherCondition = new DbWeatherCondition();

            dbWeatherCondition.TemperatureF = weatherCondition.TemperatureF;
            dbWeatherCondition.Condition = weatherCondition.Summary;
            dbWeatherCondition.CreatedDate = DateTime.Now;

            return dbWeatherCondition;
        }
    }
}