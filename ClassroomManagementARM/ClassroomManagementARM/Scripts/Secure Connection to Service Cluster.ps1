Import-PfxCertificate -Exportable -CertStoreLocation Cert:\CurrentUser\My `
        -FilePath C:\dump\madowlcert.pfx `
        -Password (ConvertTo-SecureString -String abcd123 -AsPlainText -Force)

Connect-serviceFabricCluster -ConnectionEndpoint madowlkeyvault.westeurope.cloudapp.azure.com:19000 `
    -KeepAliveIntervalInSec 10 `
    -X509Credential -ServerCertThumbprint 850A278CE7364C9E88B72F65FD38304F1137E61E `
    -FindType FindByThumbprint -FindValue 850A278CE7364C9E88B72F65FD38304F1137E61E `
    -StoreLocation CurrentUser -StoreName My