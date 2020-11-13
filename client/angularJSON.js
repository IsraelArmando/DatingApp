/*{
    "$schema": "./node_modules/@angular/cli/lib/config/schema.json",
    "version": 1,
    "newProjectRoot": "projects",
    "projects": {
      "client": {
        "projectType": "application",
        "schematics": {},
        "root": "",
        "sourceRoot": "src",
        "prefix": "app",
        "architect": {
          "build": {
            "builder": "@angular-devkit/build-angular:browser",
            "options": {
              "outputPath": "dist/client",
              "index": "src/index.html",
              "main": "src/main.ts",
              "polyfills": "src/polyfills.ts",
              "tsConfig": "tsconfig.app.json",
              "aot": true,
              "assets": [
                "src/favicon.ico",
                "src/assets"
              ],
              "styles": [
                "./node_modules/bootstrap/dist/css/bootstrap.min.css",
                "./node_modules/ngx-bootstrap/datepicker/bs-datepicker.css",
                "src/styles.css"
              ],
              "scripts": []
            },
            "configurations": {
              "production": {
                "fileReplacements": [
                  {
                    "replace": "src/environments/environment.ts",
                    "with": "src/environments/environment.prod.ts"
                  }
                ],
                "optimization": true,
                "outputHashing": "all",
                "sourceMap": false,
                "extractCss": true,
                "namedChunks": false,
                "extractLicenses": true,
                "vendorChunk": false,
                "buildOptimizer": true,
                "budgets": [
                  {
                    "type": "initial",
                    "maximumWarning": "2mb",
                    "maximumError": "5mb"
                  },
                  {
                    "type": "anyComponentStyle",
                    "maximumWarning": "6kb",
                    "maximumError": "10kb"
                  }
                ]
              }
            }
          },
          "serve": {
            "builder": "@angular-devkit/build-angular:dev-server",
            "options": {

//3.28{

              "sslKey":"./ssl/server.key",
              "sslCert":"./ssl/server.crt",
              "ssl": true,

       //}3.28

       
              "browserTarget": "client:build"
            },
            "configurations": {
              "production": {
                "browserTarget": "client:build:production"
              }
            }
          },
          "extract-i18n": {
            "builder": "@angular-devkit/build-angular:extract-i18n",
            "options": {
              "browserTarget": "client:build"
            }
          },
          "test": {
            "builder": "@angular-devkit/build-angular:karma",
            "options": {
              "main": "src/test.ts",
              "polyfills": "src/polyfills.ts",
              "tsConfig": "tsconfig.spec.json",
              "karmaConfig": "karma.conf.js",
              "assets": [
                "src/favicon.ico",
                "src/assets"
              ],
              "styles": [
                "./node_modules/bootstrap/dist/css/bootstrap.min.css",
                "./node_modules/ngx-bootstrap/datepicker/bs-datepicker.css",
                "src/styles.css"
              ],
              "scripts": []
            }
          },
          "lint": {
            "builder": "@angular-devkit/build-angular:tslint",
            "options": {
              "tsConfig": [
                "tsconfig.app.json",
                "tsconfig.spec.json",
                "e2e/tsconfig.json"
              ],
              "exclude": [
                "**///node_modules/**"
         /*     ]
            }
          },
          "e2e": {
            "builder": "@angular-devkit/build-angular:protractor",
            "options": {
              "protractorConfig": "e2e/protractor.conf.js",
              "devServerTarget": "client:serve"
            },
            "configurations": {
              "production": {
                "devServerTarget": "client:serve:production"
              }
            }
          }
        }
      }
    },
    "defaultProject": "client"
  }*/