import { BaseModel } from './BaseModel';

export class User extends BaseModel {
    nickname: string;

    constructor(id: number, nickname: string) {
        super(id);
        this.nickname = nickname;
    }
}
