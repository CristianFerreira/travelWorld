/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class Country {
        public id: number;
        public name: string;
        public continentId: number;
        public continent: Continent;

        public cities: Array<City>;

        constructor() {
        }
    }
} 