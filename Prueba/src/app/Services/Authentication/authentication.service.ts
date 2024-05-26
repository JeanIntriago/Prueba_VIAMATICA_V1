import { Injectable } from '@angular/core';
import { LoginServiceService } from '../LoginService/login-service.service';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService implements CanActivate{

constructor(
  private _loginAuth:LoginServiceService, 
  private router: Router
) { }
  
  canActivate():boolean{
    if(this._loginAuth.isLogged()){
      return true;
    }else{
      this.router.navigate(['/login']);
      return false;
    }
  }

  /*
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if(!this._loginAuth.isLogged()){
      this.router.navigate(['/login']);
      return false;
    }  
    return true;
  }
  */

}
