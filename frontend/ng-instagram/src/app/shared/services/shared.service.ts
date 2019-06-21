import { Injectable } from "@angular/core";
import { forEach } from "@angular/router/src/utils/collection";
import { ToastrService } from 'ngx-toastr';


@Injectable()
export class SharedService {

    constructor(private toastrService: ToastrService) { }

    parseServerErrors(data: any): Array<string> {
        let errors = Array<string>();

        if (data) {
            if (data.errors) {
                data.errors.forEach((error) => {
                    errors.push(error.description);
                });
            }
            if (data.error) {
                if (data.error.errors) {
                    errors = data.error.errors;
                } else {
                    errors.push(data.message);
                }
            }
        }

        return errors;
    }

    toastErrors(data: any) {
        if (data != null) {
            if (data instanceof Array) {
                data.forEach((error) => { this.toastrService.error(error) });
            } else {
                this.toastrService.error(data);
            }
        }
    }

    parseServerErrorsAndToast(data: any) {
        var errors = this.parseServerErrors(data);
        this.toastErrors(errors);
    }

}