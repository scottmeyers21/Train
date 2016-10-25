namespace MyApp.Services {

    export class CarService {
        private CarResource;

        public listCars() {
            return this.CarResource.query();
        }
        public listUserCars(userId) {
            return this.CarResource.query({ userId: userId });
        }
        public save(car) {
            return this.CarResource.save(car).$promise;
        }
        constructor($resource: angular.resource.IResourceService) {
            this.CarResource = $resource('/api/cars/:id');
        }
    }

    angular.module('MyApp').service('carService', CarService);

}