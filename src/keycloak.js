import Keycloak from 'keycloak-js';

const keycloak = new Keycloak({
  url: 'http://localhost:8080/auth',  // Replace with actual Keycloak URL
  realm: 'VisaAppRealm',              // Replace with your realm
  clientId: 'visa-connection-client', // Replace with your client ID
});

export default keycloak;
