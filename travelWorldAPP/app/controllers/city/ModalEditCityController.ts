/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalEditCityController {

        static $inject = ['CityService', 'continents', 'countries', 'toastr', '$mdDialog', 'city'];

        public cityService: CityService;
        public continents: Array<Continent>;
        public countries: Array<Country>;
        public toastr: Toastr;
        public mdDialog: any;
        public city: City;
        public cityEdit: City;

        constructor(cityService: CityService,continents: Array<Continent>,
                     toastr: Toastr, mdDialog: any, city: City) {
            this.cityService = cityService;
            this.continents = continents;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.city = city;
            this.cityEdit = new City();
            this.cityEdit = this.city;
        }

        public editCity(city :City) :void {       
          this.cityService.editCity(city)
                .then((data) => {                 
                    this.mdDialog.cancel();
                    this.toastr.success("Cidade editada com sucesso!");                          
                })
                .catch((response) => {
                    this.toastr.error('Pais não pode ser editado!');
                })   
        }

        public cancel(): void {
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalEditCityController', ModalEditCityController);
}