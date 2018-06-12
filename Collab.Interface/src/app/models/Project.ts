import { BaseModel } from './BaseModel';

export class Project extends BaseModel {
    name: string;
    description: string;

    constructor(id: number, name: string, description?: string) {
        super(id);
        this.name = name;
        this.description = description;
    }
}
