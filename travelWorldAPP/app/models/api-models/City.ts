/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class City {
        public id: number;
        public name: string;
        public countryId: number;
        
        public country: Country;


        constructor() {
        }
    }
} 