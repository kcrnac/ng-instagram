import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UserService } from './user.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private userService: UserService
    ) { }

    isAuthenticated: boolean;

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): boolean {
        this.userService.isAuthenticated.subscribe((isAuthenticated) => {
            if (isAuthenticated) {
                this.isAuthenticated = true;
            } else {
                this.router.navigate(['/login']);
                this.isAuthenticated = false;
            }
        });

        return this.isAuthenticated;
    }
}
