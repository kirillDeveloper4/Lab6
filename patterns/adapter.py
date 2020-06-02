import json
from typing import Iterable


class SensorToJson:
    monitored_sensors = []

    def add_sensors(self, sensors: Iterable):
        for sensor in sensors:
            if sensor not in self.monitored_sensors:
                self.monitored_sensors.append(sensor)

    def get_data(self):
        data_encoded = {}
        for sensor in self.monitored_sensors:
            data = sensor.get_data()
            sensor_type = sensor.sensor_type
            if sensor_type not in data_encoded:
                data_encoded[sensor_type] = []
            data_encoded[sensor_type].append(data)
        return json.dumps(data_encoded)
