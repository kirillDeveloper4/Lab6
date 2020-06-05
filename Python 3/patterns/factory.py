from enum import Enum


class SensorTypes(Enum):
    TEMPERATURE = 0
    PRESSURE = 1


class Sensor:
    data = {}

    def __init__(self):
        pass

    def measure(self):
        pass

    def get_data(self):
        return self.data


class TemperatureSensor(Sensor):
    sensor_type = SensorTypes.TEMPERATURE
    data = {}

    def __init__(self):
        super().__init__()

    def measure(self):
        print("Measuring temperature")
        self.data['temperature'] = 30


class PressureSensor(Sensor):
    sensor_type = SensorTypes.PRESSURE
    data = {}

    def __init__(self):
        super().__init__()

    def measure(self):
        print("Measuring pressure")
        self.data['pressure'] = 1


class _SensorFactory:
    sensor_classes = {
        SensorTypes.TEMPERATURE: TemperatureSensor,
        SensorTypes.PRESSURE: PressureSensor
    }

    def __init__(self):
        print("init sensor factory")

    def create_sensor(self, sensor_type: SensorTypes, *args, **kwargs):
        if sensor_type in self.sensor_classes:
            return self.sensor_classes[sensor_type](*args, **kwargs)


SensorFactory = _SensorFactory()
