/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalDeleteCountryController {

        static $inject = ['CountryService', 'toastr', '$mdDialog', 'deleteCountries'];

        public countryService: CountryService;
        public toastr: Toastr;
        public mdDialog: any;
        public deleteCountries: Array<Country>;

        constructor(countryService: CountryService, toastr: Toastr, mdDialog: any, deleteCountries: Array<Country>) {
            this.countryService = countryService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.deleteCountries = deleteCountries;
        }

        public deleteCountry() :void {   

             this.countryService.deleteCountryAlot(this.deleteCountries)
                .then((data) => {  
                    if(data.length > 1)
                        this.toastr.success("Paises excluidos com sucesso!"); 
                    else    
                        this.toastr.success("Pais excluido com sucesso!");
             
                    this.mdDialog.cancel();                                         
                })
                .catch((response) => {
                    this.toastr.error('Pais não pode ser excluido!');
                })      
        }

        public cancel(): void {
            console.log("cancel");
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalDeleteCountryController', ModalDeleteCountryController);
}