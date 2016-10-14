namespace MyApp.Controllers {

    export class HomeController {
        public cars;

        constructor
        (
            private carService: MyApp.Services.CarService,
            private $location: angular.ILocationService
        ) {
            this.cars = this.carService.listCars();
        }
    }
    export class AddCarController {
        public newCar;
        public save() {
            this.carService.save(this.newCar).then(() => this.newCar = {}); 
        }
        constructor(
            private carService: MyApp.Services.CarService,
            private $location: angular.ILocationService
        ) { }

    }
    export class ModIncomingController {
        public cars;

        constructor
            (
            private carService: MyApp.Services.CarService,
            private $location: angular.ILocationService
            ) {
            this.cars = this.carService.listCars();
        }
    }

    export class AboutController {

    }
}