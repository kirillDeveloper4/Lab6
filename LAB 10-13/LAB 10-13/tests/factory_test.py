from unittest import TestCase
from patterns.factory import SensorFactory, SensorTypes


class TestFactory(TestCase):
    def test(self):
        print("running factory test")
        temperature = SensorFactory.create_sensor(SensorTypes.TEMPERATURE)
        print(temperature)
        temperature.measure()
        self.assertDictEqual(temperature.get_data(), {"temperature": 30})

        pressure = SensorFactory.create_sensor(SensorTypes.PRESSURE)
        print(pressure)
        pressure.measure()
        self.assertDictEqual(pressure.get_data(), {"pressure": 1})
