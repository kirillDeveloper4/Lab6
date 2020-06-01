class SensorIterator:
    _cursor = -1

    def __init__(self, sensor_array):
        self._sensor_array = sensor_array
        print(len(self._sensor_array))
        pass

    def __iter__(self):
        self._cursor = -1
        return self

    def __next__(self):
        if self._cursor + 1 >= len(self._sensor_array):
            raise StopIteration()
        self._cursor += 1
        self._sensor_array[self._cursor].measure()
        return self._sensor_array[self._cursor]
