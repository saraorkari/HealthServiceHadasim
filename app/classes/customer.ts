import { Address } from "./address";
import { Vaccination } from "./Vaccination";

export class Customer{

    constructor(public NumCustomer?:number,
    public FirstName?:string,
    public LastName?:string,
    public Id?:string,
    public AddressId?:number,
    public DateOfBirth?:Date,
    public Telephone?:string,
    public Mobile?:string,
    public Img?:string,
    public VaccinationId?:number,
    public Count?:number,
    public Cuvid19Positive?:Date,
    public Recovery?:Date,
    public Address?: Address,
    public Vaccination?:Vaccination[]
    ){
    }
}