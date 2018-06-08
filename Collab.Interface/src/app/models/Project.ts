import { BaseModel } from './BaseModel';

export class Project extends BaseModel {
    name: string;

    constructor(id: number, name: string) {
        super(id);
        this.name = name;
    }
}
