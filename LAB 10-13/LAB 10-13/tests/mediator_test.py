from unittest import TestCase
from patterns.mediator import *


class TestMediator(TestCase):
    def test(self):
        mediator = Mediator()
        point1 = LocalPoint(mediator, "ServerModule")
        point2 = LocalPoint(mediator, "Operator")
        server = ServerModule(mediator, "LocalPoint")
        operator = Operator(mediator, "ServerModule")
        server.send("Check1")
        operator.send("Check2")
        point1.send("Check3")
        point2.send("Check4")
