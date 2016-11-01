namespace MyApp.Controllers {

    export class AccountController {
        public externalLogins;
        public cars;


        public getClaim(type) {
            return this.accountService.getClaim(type);
        }

        public isLoggedIn() {
            return this.accountService.isLoggedIn();
        }

        public logout() {
            this.accountService.logout();
        }

        public getUserId() {
            this.accountService.getUserId();
        }

        public getExternalLogins() {
            return this.accountService.getExternalLogins();
        }

        constructor(private accountService: MyApp.Services.AccountService, private $location: ng.ILocationService, private carService: MyApp.Services.CarService) {
            this.getExternalLogins().then((results) => {
                this.externalLogins = results;
                this.cars = this.carService.listCars();
            });
        }
    }

    angular.module('MyApp').controller('AccountController', AccountController);


    export class LoginController {
        public loginUser;
        public validationMessages;

        public login() {
            this.accountService.login(this.loginUser).then(() => {
                this.$location.path('/');
            }).catch((results) => {
                this.validationMessages = results;
            });
        }
        public cancel() {
            this.loginUser = {}
        }
        constructor(private accountService: MyApp.Services.AccountService, private $location: ng.ILocationService) { }
    }


    export class RegisterController {
        public registerUser;
        public validationMessages;

        public register() {
            this.accountService.register(this.registerUser).then(() => {
                this.$location.path('/login');
            }).catch((results) => {
                this.validationMessages = results;
            });
        }
        public cancel() {
            this.registerUser = {}
        }

        constructor(private accountService: MyApp.Services.AccountService, private $location: ng.ILocationService) { }
    }



    export class ExternalLoginController {

        constructor($http: ng.IHttpService, private $location: ng.ILocationService, private accountService: MyApp.Services.AccountService) {
            // if the user is already registered then redirect home else register
            let response = accountService.parseOAuthResponse($location.hash());
            let externalAccessToken = response['access_token'];
            accountService.getUserInfo(externalAccessToken).then((userInfo: any) => {
                if (userInfo.hasRegistered) {
                    accountService.storeUserInfo(response);
                    $location.path('/');
                } else {
                    $location.path('/externalRegister');
                }
            });
        }
    }


    export class ExternalRegisterController {
        private externalAccessToken;
        public registerUser;
        public validationMessages;

        public register() {
            this.accountService.registerExternal(this.registerUser.email, this.externalAccessToken)
                .then((result) => {
                    this.$location.path('/login');
                }).catch((result) => {
                    this.validationMessages = result;
                });
        }

        constructor(private accountService: MyApp.Services.AccountService, private $location: ng.ILocationService) {
            let response = accountService.parseOAuthResponse($location.hash());
            this.externalAccessToken = response['access_token'];
        }

    }

    export class ConfirmEmailController {
        public validationMessages;

        constructor(
            private accountService: MyApp.Services.AccountService,
            private $http: ng.IHttpService,
            private $routeParams: ng.route.IRouteParamsService,
            private $location: ng.ILocationService
        ) {
            let userId = $routeParams['userId'];
            let code = $routeParams['code'];
            accountService.confirmEmail(userId, code)
                .then((result) => {
                    this.$location.path('/');
                }).catch((result) => {
                    this.validationMessages = result;
                });
        }
    }

}