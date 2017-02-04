/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalCreateCountryController {

        static $inject = ['CountryService', 'continents', 'toastr', '$mdDialog'];

        public countryService: CountryService;
        public continents: Array<Continent>;
        public toastr: Toastr;
        public mdDialog: any;
        public country: Country;
        

        constructor(countryService: CountryService, continents: Array<Continent>,
                     toastr: Toastr, mdDialog: any) {
            this.countryService = countryService;
            this.continents = continents;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.country = new Country();
        }

        public createCountry() :void {   
          console.log(this.country);      
          this.countryService.saveCountry(this.country)
                .then((data) => {                 
                    this.mdDialog.cancel();
                    this.toastr.success("Pais criado com sucesso!");                          
                })
                .catch((response) => {
                    this.toastr.error('Pais não pode ser criado!');
                })   
        }

        public cancel(): void {
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalCreateCountryController', ModalCreateCountryController);
}