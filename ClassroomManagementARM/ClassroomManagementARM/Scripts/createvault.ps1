$subid = "bc0b4843-fb66-4fa1-9e1b-6dbc8ec156a4"
$loc = "West Europe"
$rg = "madowlsf"
$vn = "madowlkeyvault"

# Replace with Service Principal
Login-AzureRmAccount 

Select-AzureRmSubscription -SubscriptionId $subid

New-AzureRmResourceGroup -Name $rg -Location $loc
New-AzureRmKeyVault -VaultName $vn -Location $loc -ResourceGroupName $rg

Set-AzureRmKeyVaultAccessPolicy -VaultName $vn -ResourceGroupName $rg -EnabledForDeployment

Invoke-AddCertToKeyVault -SubscriptionId $subid -ResourceGroupName $rg -Location $loc -VaultName $vn -CertificateName "madowlcert" -Password abcd123 -CreateSelfSignedCertificate -DnsName madowl.microsoft.com -OutputPath C:\cert

#Name  : CertificateThumbprint
#Value : 850A278CE7364C9E88B72F65FD38304F1137E61E

#Name  : SourceVault
#Value : /subscriptions/bc0b4843-fb66-4fa1-9e1b-6dbc8ec156a4/resourceGroups/madowlsf/providers/Microsoft.KeyVault/vaults/madowlkeyvault

#Name  : CertificateURL
#Value : https://madowlkeyvault.vault.azure.net:443/secrets/madowlcert/6e137553919c4cf188a8562410c1522c
