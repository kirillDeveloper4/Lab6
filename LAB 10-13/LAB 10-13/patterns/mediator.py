class BaseTalkable:
    mediator = None
    target_type = None
    own_type = None

    def __init__(self, mediator, target_type):
        self.mediator = mediator
        if self.own_type:
            if self.own_type not in self.mediator.talkers:
                self.mediator.talkers[self.own_type] = []
            self.mediator.talkers[self.own_type].append(self)
        self.target_type = target_type

    def send(self, message):
        if self.mediator:
            self.mediator.send(message, self.target_type)

    def receive(self, message):
        print(f"{self.own_type} Received \"{message}\" from mediator", )


class LocalPoint(BaseTalkable):
    own_type = "LocalPoint"


class ServerModule(BaseTalkable):
    own_type = "ServerModule"


class Operator(BaseTalkable):
    own_type = "Operator"


class Mediator:
    talkers = {}

    def __init__(self):
        pass

    def send(self, message, target_type):
        if target_type in self.talkers:
            for target in self.talkers[target_type]:
                target.receive(message)
