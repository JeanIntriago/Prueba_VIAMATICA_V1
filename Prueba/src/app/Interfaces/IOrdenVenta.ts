export interface IOrdenVenta {
    Total : number;
    FechaRegistro: Date;
    Productos : {IdProducto:number}[];
}
