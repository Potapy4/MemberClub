import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class HttpService {
    protected headers = new HttpHeaders();

    constructor(protected http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) { }

    protected getHeaders(): HttpHeaders {
        return this.headers;
    }

    public getRequest<T>(url: string, httpParams?: any): Observable<T> {
        return this.http.get<T>(this.buildUrl(url), { headers: this.getHeaders(), params: httpParams });
    }

    public postRequest<T>(url: string, payload: object, httpParams?: any): Observable<T> {
        return this.http.post<T>(this.buildUrl(url), payload, { headers: this.getHeaders(), params: httpParams });
    }

    protected buildUrl(url: string): string {
        return this.baseUrl + url;
    }
}