import { BaseModel } from './BaseModel';

export class User extends BaseModel {
    nickname: string;
    email: string;

    constructor(nickname: string, email: string, id?: number) {
        super(id);
        this.nickname = nickname;
        this.email = email;
    }
}
