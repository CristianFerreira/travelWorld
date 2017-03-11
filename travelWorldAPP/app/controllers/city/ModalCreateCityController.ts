/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalCreateCityController {

        static $inject = ['CityService', 'continents', 'toastr', '$mdDialog'];

        public cityService: CityService;
        public continents: Array<Continent>;
        public toastr: Toastr;
        public mdDialog: any;
        public city: City;
        public continent: Continent;
        public filterCountries: Array<Country>;
        public filterContinents: Array<Continent>;
        

        constructor(cityService: CityService, continents: Array<Continent>,
                     toastr: Toastr, mdDialog: any) {
            this.cityService = cityService;
            this.continents = continents;
            this.filterCountries = new Array<Country>();
            this.filterContinents = new Array<Continent>();
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.city = new City();
            this.continent = new Continent();
            this.populationContinentExistCountry();
        }

        public createCity() :void {   
   
          this.cityService.saveCity(this.city)
                .then((data) => {                 
                    this.mdDialog.cancel();
                    this.toastr.success("Cidade criada com sucesso!");                          
                })
                .catch((response) => {
                    this.toastr.error('Cidade não pode ser criada!');
                })   
        }

        public populationContinentExistCountry(){
             if(this.continents){
                this.filterContinents = this.continents.filter((c) => {
                    return c.countries.length > 0
                })
            }
        }

        public queryCountryTheContinent(continent :Continent) {
            if(continent){
                this.filterCountries = continent.countries.filter((c) => { return c })
                this.city.country =  this.filterCountries[0];
            }              
        }

        public cancel(): void {
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalCreateCityController', ModalCreateCityController);
}