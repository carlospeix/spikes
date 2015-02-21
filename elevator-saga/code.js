/*
Esta version casi pasa el challenge 6, casi siempre.

Es un poco burda porque envia las llamadas a todos los ascensores y
envia el ascensor al piso 0 cuando esta idle.

Lo que agrego aqui es que ordeno la cola de pedidos con cada uno.
*/
{
    init: function(elevators, floors) {
        
        function ElevatorsBoostraper(elevators, floors) {
            var elevators = elevators;
            var floors = floors;
            
            for (var floorNum in floors) {
                floors[floorNum].on("up_button_pressed", upButtonPressedOnFloor(floorNum));
                floors[floorNum].on("down_button_pressed", downButtonPressedOnFloor(floorNum));
            };
            
            for (var elevatorNum in elevators) {
                var elevatorFloorButtonPressed = function(elevatorNum) { return function(floorNum) {
                    askedFloorOnElevator(floorNum, elevatorNum);
                }};
        
                var elevatorIdle = function(elevatorNum) { return function() {
                    elevatorIsIdle(elevatorNum);
                }};
            
                elevators[elevatorNum].on("floor_button_pressed", elevatorFloorButtonPressed(elevatorNum));
                elevators[elevatorNum].on("idle", elevatorIdle(elevatorNum));
            }

            function upButtonPressedOnFloor(floorNum) {
                for (var elevatorNum in elevators) {
                    elevators[elevatorNum].goToFloor(floorNum);
                }
                console.log("Asked up floor " + floorNum);
            }
            
            function downButtonPressedOnFloor(floorNum) {
                for (var elevatorNum in elevators) {
                    elevators[elevatorNum].goToFloor(floorNum);
                }
                console.log("Asked down floor " + floorNum);
            }
            
            function askedFloorOnElevator(floorNum, elevatorNum) {
                elevators[elevatorNum].goToFloor(floorNum);
                updateRouteOnElevator(elevatorNum);
                console.log("Asked floor " + floorNum + " on elevator " + elevatorNum);
            }
            
            function elevatorIsIdle(elevatorNum) {
                elevators[elevatorNum].goToFloor(0);
                console.log("Elevator " + elevatorNum + "  idle");
            }
            
            function updateRouteOnElevator(elevatorNum) {
                elevators[elevatorNum].destinationQueue = recalculateQueueForElevator(elevatorNum);
                elevators[elevatorNum].checkDestinationQueue();
            }
            
            function recalculateQueueForElevator(elevatorNum) {
                return elevators[elevatorNum].destinationQueue.sort();
            }
        };
        
        function ElevatorDirectionStoped(elevator) {
        }
        
        function ElevatorDirectionUp(elevator) {
            this.elevator = elevator;
        }
        
        function ElevatorDirectionUp(elevator) {
            this.elevator = elevator;
        }
        
        var boostraper = new ElevatorsBoostraper(elevators, floors);
    },
    update: function(dt, elevators, floors) {
        // We normally don't need to do anything here
    }
}