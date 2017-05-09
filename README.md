# Account Number Tools

## Project Description
The library supports the formal check of national account and international credit card numbers and converting between national account numbers and IBAN.

The following countries are supported by validation:

* Albania
* Belgium
* Germany
* Poland
* Portugal

more to come.

At the moment their are 10 methods to calculate the check digits for german account numbers implemented. Hopefully I will find the time to add the other 100 methods.

The library provides the functionality to make a formal check of credit card numbers. It can calculate the check digit for them via Luhn/mod 10 algorithm. A length check is also processed.

The library is available as [![N|NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)](http://nuget.org/List/Packages/AccountNumberTools) package too.

## Usage examples

#### checking a german account number
```csharp
// create a default instance to check account numbers with bank codes
IAccountNumberCheckWithBankCode sut = new AccountNumberCheck();
// first argument is the account number, second is the bank code
// the mapping of the bank code to a check method is done internally via the official bank code list
sut.IsValid(new GermanAccountNumber { AccountNumber = "4234322787", BankCode = "87070000" });

// or shortcut via extension methods
new GermanAccountNumber { AccountNumber = "4234322787", BankCode = "87070000" }).IsValid();
```

#### checking credit card numbers
```csharp
// create a default instance to check credit card numbers
ICreditCardNumberCheck sut = new CreditCardNumberCheck();
// first argument is the credit card number (can include spaces, minus or other non-numeric chars)
// second is a specific credit card network identifier or automatic
sut.IsValid("4234 3227 8778 9876", CreditCardNetwork.Visa);
// or with automatic detection of the credit card network based upon the IIN prefix
sut.IsValid("4234 3227 8778 9876", CreditCardNetwork.Automatic);
```

#### converting a national account number to IBAN
```csharp
// create a default instance of the converter
IIBANConvert sut = new IBANConvert();
// converting
sut.ToIBAN(new GermanAccountNumber { BankCode = "1234 5678", AccountNumber = "9090 1234 00" });
// and back
var nationalAccountNumber = sut.FromIBAN("DE42123456789090123400");
```

## Support it
If you find the project useful and you wish to support the future development feel free to support it with a donation.

## Donate
[![N|Donate](https://www.paypal.com/en_US/i/btn/btn_donateCC_LG_global.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=9M5BHCMC4DH42)

Beside a donation patches, bug reports, feedback and other useful help are always welcome!
