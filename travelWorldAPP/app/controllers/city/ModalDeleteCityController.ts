/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalDeleteCityController {

        static $inject = ['CityService', 'toastr', '$mdDialog', 'deleteCities'];

        public cityService: CityService;
        public toastr: Toastr;
        public mdDialog: any;
        public deleteCities: Array<City>;

        constructor(cityService: CityService, toastr: Toastr, mdDialog: any, deleteCities: Array<City>) {
            this.cityService = cityService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.deleteCities = deleteCities;
        }

        public deleteCity() :void {   

             this.cityService.deleteCityAlot(this.deleteCities)
                .then((data) => {  
                    if(data.length > 1)
                        this.toastr.success("Cidades excluidas com sucesso!"); 
                    else    
                        this.toastr.success("Cidade excluida com sucesso!");
             
                    this.mdDialog.cancel();                                         
                })
                .catch((response) => {
                    this.toastr.error('Cidade não pode ser excluida!');
                })      
        }

        public cancel(): void {
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalDeleteCityController', ModalDeleteCityController);
}