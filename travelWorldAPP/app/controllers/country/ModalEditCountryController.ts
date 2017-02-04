/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalEditCountryController {

        static $inject = ['CountryService', 'continents', 'toastr', '$mdDialog', 'country'];

        public countryService: CountryService;
        public continents: Array<Continent>;
        public toastr: Toastr;
        public mdDialog: any;
        public country: Country;
        public countryEdit: Country;

        constructor(countryService: CountryService,continents: Array<Continent>,
                     toastr: Toastr, mdDialog: any, country: Country) {
            this.countryService = countryService;
            this.continents = continents;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.country = country;
            this.countryEdit = new Country();
            this.countryEdit = this.country;
        }

        public editCountry(country :Country) :void {      
        console.log(this.country);  
          this.countryService.editCountry(country)
                .then((data) => {                 
                    this.mdDialog.cancel();
                    this.toastr.success("Pais editado com sucesso!");                          
                })
                .catch((response) => {
                    this.toastr.error('Pais não pode ser editado!');
                })   
        }

        public cancel(): void {
            console.log("cancel");
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalEditCountryController', ModalEditCountryController);
}