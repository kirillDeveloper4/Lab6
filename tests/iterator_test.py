from unittest import TestCase
from patterns.factory import SensorFactory, SensorTypes
from patterns.iterator import SensorIterator
from patterns.adapter import SensorToJson


class TestIterator(TestCase):
    def test(self):
        adapter = SensorToJson()
        sensors = []
        for i in range(4):
            temperature = SensorFactory.create_sensor(SensorTypes.TEMPERATURE)
            pressure = SensorFactory.create_sensor(SensorTypes.PRESSURE)
            sensors.extend([temperature, pressure])

        for item in SensorIterator(sensors):
            adapter.add_sensor(item)

        data = adapter.get_data()

        self.assertTrue(data)
