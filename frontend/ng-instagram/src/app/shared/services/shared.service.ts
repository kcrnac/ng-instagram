import { Injectable } from "@angular/core";
import { forEach } from "@angular/router/src/utils/collection";


@Injectable()
export class SharedService {

    parseServerErrors(data: any): Array<string> {
        let errors = Array<string>();

        if (data && data.errors) {
            data.errors.forEach((error) => {
                errors.push(error.description);
            });
        }

        return errors;
    }

}