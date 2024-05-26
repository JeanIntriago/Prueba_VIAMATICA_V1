import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginServiceService } from "../LoginService/login-service.service";


@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(private authentication:LoginServiceService) {        
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        //OBTENER EL TOKEN
        const token = this.authentication.getToken();

        if(token){
            var request: any = request.clone({
                setHeaders:{
                    Authorization: `Bearer ${token}`
                }
            });
        }
        return next.handle(request);
    }
}
