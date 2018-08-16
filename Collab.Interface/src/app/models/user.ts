import { BaseModel } from './BaseModel';

export class User extends BaseModel {
    nickname: string;
    emailAddress: string;

    constructor(id: number, nickname: string, emailAddress: string) {
        super(id);
        this.nickname = nickname;
        this.emailAddress = emailAddress;
    }
}
