from unittest import TestCase
from patterns.factory import SensorFactory, SensorTypes
from patterns.adapter import SensorToJson


class TestAdater(TestCase):
    def test(self):
        adapter = SensorToJson()
        for i in range(4):
            temperature = SensorFactory.create_sensor(SensorTypes.TEMPERATURE)
            temperature.measure()
            pressure = SensorFactory.create_sensor(SensorTypes.PRESSURE)
            pressure.measure()
            adapter.add_sensors([temperature, pressure])

        data = adapter.get_data()
        print(data)
        self.assertTrue(str(0) in data)
        self.assertTrue(str(1) in data)
