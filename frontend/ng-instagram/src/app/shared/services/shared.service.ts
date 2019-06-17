import { Injectable } from "@angular/core";
import { forEach } from "@angular/router/src/utils/collection";


@Injectable()
export class SharedService {

    parseServerErrors(data: any): Array<string> {
        let errors = Array<string>();

        if (data) {
            if (data.errors) {
                data.errors.forEach((error) => {
                    errors.push(error.description);
                });
            }
            if (data.error) {
                errors = data.error.errors;
            }
        }

        return errors;
    }

}