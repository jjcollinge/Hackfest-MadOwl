import { bootstrap }    from '@angular/platform-browser-dynamic';

import { AppComponent } from './app.component';
import { HTTP_PROVIDERS } from '@angular/http';
import { JSONP_PROVIDERS }  from '@angular/http';

bootstrap(AppComponent, [ HTTP_PROVIDERS, JSONP_PROVIDERS ]);
