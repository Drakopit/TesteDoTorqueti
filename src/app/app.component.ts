import { Component } from '@angular/core';
import { User } from './Models/User';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from './service/authentication.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass', './app.component.css']
})
export class AppComponent {
  title = 'TesteDoTorqueti';
  public User = new User();
  public returnUrl: string;
  public error = '';

  constructor(private route: ActivatedRoute,
              private router: Router,
              private authenticationService: AuthenticationService) {}

  public getLogin() {
    this.router.navigate(['/']);
    this.authenticationService.login(this.User.Login, this.User.Senha)
    .pipe(first())
    .subscribe(
        data => {
          console.log(data);
          this.router.navigate(['/']);
        },
        error => {
          this.error = error;
        });
    }
}
