import { HttpClient } from "@angular/common/http";
import { OnCallDeveloperResponseModel } from "../models/oncalldeveloper";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class OnCallDataService {
    constructor(private readonly client: HttpClient) {}

    public getCurrentHelpInformation(): Observable<OnCallDeveloperResponseModel> {
        return this.client.get<OnCallDeveloperResponseModel>(environment.onCallApi + 'oncalldeveloper');
    }
}