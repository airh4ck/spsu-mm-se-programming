package model.WeatherModel;

import model.WeatherData.WeatherData;
import org.junit.jupiter.api.Test;

import java.util.HashMap;

import static org.junit.jupiter.api.Assertions.*;

class StormglassModelTest {

	@Test
	void StormglassModelInitializationExpectNull() {
		assertNull(new StormglassModel().data);
	}

	@Test
	void updateState() {
		WeatherModel weatherModel = new StormglassModel();

		HashMap<String, Double> newStats = new HashMap<>();

		newStats.put("airTemperatureC", 10.0);
		newStats.put("airTemperatureF", 50.0);
		newStats.put("cloudCover", 10.0);
		newStats.put("humidity", 12.0);
		newStats.put("precipitation", 4.0);
		newStats.put("windDirection", 51.0);
		newStats.put("windSpeed", 1.0);

		WeatherModel expectedModel = new StormglassModel();
		expectedModel.data = new WeatherData(
				10.0,
				50.0,
				10.0,
				12.0,
				4.0,
				51.0,
				1.0
		);
		weatherModel.updateState(newStats);

		assertEquals(expectedModel, weatherModel);
	}
}