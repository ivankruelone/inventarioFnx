CREATE TABLE IF NOT EXISTS [ajustes] (
    [id] integer PRIMARY KEY NOT NULL,
    [sucursal] integer NOT NULL,
    [producto_id] integer NOT NULL,
    [cantidadvieja] integer NOT NULL,
    [cantidadnueva] integer NOT NULL,
    [usuario_id] integer NOT NULL,
    [fecha] datetime NOT NULL
);
CREATE TABLE IF NOT EXISTS [config] (
    [id] integer PRIMARY KEY NOT NULL,
    [sucursal] integer NOT NULL DEFAULT 0,
    [nombre] varchar(255) NOT NULL DEFAULT 'No asignada'
);
CREATE TABLE IF NOT EXISTS [cortes] (
    [id] integer PRIMARY KEY NOT NULL,
    [fondo] decimal NOT NULL DEFAULT 0,
    [retiro] decimal NOT NULL DEFAULT 0,
    [ventas] decimal NOT NULL DEFAULT 0,
    [total] decimal NOT NULL DEFAULT 0,
    [dinero] decimal NOT NULL DEFAULT 0,
    [faltante] decimal NOT NULL DEFAULT 0,
    [sobrante] decimal NOT NULL DEFAULT 0,
    [fecha] datetime NOT NULL,
    [usuario_id] integer NOT NULL
);
CREATE TABLE IF NOT EXISTS [destinos] (
    [id] integer PRIMARY KEY NOT NULL,
    [suc] integer NOT NULL UNIQUE,
    [nomsuc] varchar(50) NOT NULL
);
CREATE TABLE IF NOT EXISTS [entradas_c] (
    [id] integer PRIMARY KEY NOT NULL,
    [folio] varchar(20) NOT NULL,
    [fecha] datetime NOT NULL,
    [usuario_id] integer NOT NULL,
    [cerrada] tinyint NOT NULL DEFAULT 0,
    [fecha_cierre] datetime
);
CREATE TABLE IF NOT EXISTS [entradas_d] (
    [id] integer PRIMARY KEY NOT NULL,
    [c_id] integer NOT NULL,
    [producto_id] integer NOT NULL,
    [cantidad] integer NOT NULL
);
CREATE TABLE IF NOT EXISTS [fondos] (
    [id] integer PRIMARY KEY NOT NULL,
    [monto] decimal NOT NULL,
    [fecha] datetime NOT NULL,
    [responsable] integer NOT NULL,
    [activo] tinyint NOT NULL DEFAULT 1,
    [cancelado] datetime,
    [corte_id] integer NOT NULL DEFAULT 0
);
CREATE TABLE IF NOT EXISTS [inv] (
    [id] integer PRIMARY KEY NOT NULL,
    [producto_id] integer NOT NULL,
    [cantidad] integer NOT NULL
);
CREATE TABLE IF NOT EXISTS [inv_c] (
    [id] integer PRIMARY KEY NOT NULL,
    [fecha] datetime NOT NULL,
    [usuario_id] integer NOT NULL DEFAULT 1
);
CREATE TABLE IF NOT EXISTS [inv_d] (
    [id] integer PRIMARY KEY NOT NULL,
    [c_id] integer NOT NULL,
    [producto_id] integer NOT NULL,
    [cantidad] integer NOT NULL
);
CREATE TABLE IF NOT EXISTS [inv_h] (
    [id] integer PRIMARY KEY NOT NULL,
    [c_id] integer NOT NULL,
    [producto_id] integer NOT NULL,
    [cantidad] integer NOT NULL
);
CREATE TABLE IF NOT EXISTS items (datetime INTEGER NOT NULL, sampletext TEXT );
CREATE TABLE IF NOT EXISTS [productos] (
    [id] integer PRIMARY KEY NOT NULL,
    [clave] varchar(14) NOT NULL,
    [ean] varchar(14),
    [descripcion] varchar(255) NOT NULL,
    [precio] numeric(8,2) NOT NULL DEFAULT 10,
    [cambio] datetime,
    [inv] integer NOT NULL DEFAULT 0
);
CREATE TABLE IF NOT EXISTS [retiro_fondo] (
    [id] integer PRIMARY KEY NOT NULL,
    [monto] decimal NOT NULL,
    [fecha] datetime NOT NULL,
    [responsable] integer NOT NULL,
    [activo] tinyint NOT NULL DEFAULT 1,
    [corte_id] integer NOT NULL DEFAULT 0
);
CREATE TABLE IF NOT EXISTS [salidas_c] (
    [id] integer PRIMARY KEY NOT NULL,
    [folio] varchar(20) NOT NULL,
    [fecha] datetime NOT NULL,
    [usuario_id] integer NOT NULL,
    [tipo_id] integer NOT NULL,
    [destino] integer NOT NULL
);
CREATE TABLE IF NOT EXISTS [salidas_d] (
    [id] integer PRIMARY KEY NOT NULL,
    [c_id] integer NOT NULL,
    [producto_id] integer NOT NULL,
    [cantidad] integer NOT NULL
);
CREATE TABLE IF NOT EXISTS [salidas_t] (
    [id] integer PRIMARY KEY NOT NULL,
    [producto_id] integer NOT NULL,
    [cantidad] integer NOT NULL
);
CREATE TABLE IF NOT EXISTS [ticket] (
    [rfc] varchar(12) NOT NULL,
    [razonsocial] varchar(47) NOT NULL,
    [linea1] varchar(47) NOT NULL,
    [linea2] varchar(47) NOT NULL,
    [linea3] varchar(47),
    [suc1] varchar(47) NOT NULL,
    [suc2] varchar(47) NOT NULL,
    [suc3] varchar(47),
    [id] integer PRIMARY KEY NOT NULL
);
CREATE TABLE IF NOT EXISTS [tipo_salida] (
    [id] integer PRIMARY KEY NOT NULL,
    [tipo] integer NOT NULL,
    [salida] varchar(50) NOT NULL
);
CREATE TABLE IF NOT EXISTS [usuarios] (
    [id] integer PRIMARY KEY NOT NULL,
    [username] varchar(50) NOT NULL,
    [password] varchar(50) NOT NULL,
    [nombre] varchar(50) NOT NULL,
    [nivel] tinyint NOT NULL,
    [nomina] integer NOT NULL DEFAULT 0,
    [activo] tinyint NOT NULL DEFAULT 1
);
CREATE TABLE IF NOT EXISTS [venta_c] (
    [id] integer PRIMARY KEY NOT NULL,
    [folio] varchar(50) NOT NULL,
    [fecha] datetime NOT NULL,
    [enviada] tinyint NOT NULL DEFAULT 0,
    [corte_id] integer NOT NULL DEFAULT 0,
    [usuario_id] integer NOT NULL DEFAULT 1,
    [cerrada] tinyint NOT NULL DEFAULT 0,
    [sucursal] integer NOT NULL DEFAULT 0
);
CREATE TABLE IF NOT EXISTS [venta_d] (
    [id] integer PRIMARY KEY NOT NULL,
    [c_id] integer NOT NULL,
    [producto_id] integer NOT NULL,
    [precio] decimal NOT NULL DEFAULT 10,
    [cantidad] integer NOT NULL DEFAULT 1
);
CREATE INDEX IF NOT EXISTS [IX_Fecha_fondos] ON [fondos] ([fecha]);
CREATE INDEX IF NOT EXISTS [IX_Folio] ON [venta_c] ([folio]);
CREATE INDEX IF NOT EXISTS [IX_Nomina] ON [usuarios] ([nomina]);
CREATE INDEX IF NOT EXISTS [IX_ajustes_fecha] ON [ajustes] ([fecha]);
CREATE INDEX IF NOT EXISTS [IX_ajustes_producto_id] ON [ajustes] ([producto_id]);
CREATE INDEX IF NOT EXISTS [IX_ajustes_sucursal] ON [ajustes] ([sucursal]);
CREATE INDEX IF NOT EXISTS [IX_ajustes_usuario_id] ON [ajustes] ([usuario_id]);
CREATE INDEX IF NOT EXISTS [IX_c_id] ON [venta_d] ([c_id]);
CREATE INDEX IF NOT EXISTS [IX_clave] ON [productos] ([clave]);
CREATE INDEX IF NOT EXISTS [IX_corte_id] ON [venta_c] ([corte_id]);
CREATE INDEX IF NOT EXISTS [IX_cortes_fecha] ON [cortes] ([fecha]);
CREATE INDEX IF NOT EXISTS [IX_cortes_usuario_id] ON [cortes] ([usuario_id]);
CREATE INDEX IF NOT EXISTS [IX_destinos_suc] ON [destinos] ([suc]);
CREATE INDEX IF NOT EXISTS [IX_entradas_c_fecha] ON [entradas_c] ([fecha]);
CREATE INDEX IF NOT EXISTS [IX_entradas_c_folio] ON [entradas_c] ([folio]);
CREATE INDEX IF NOT EXISTS [IX_entradas_c_usuario_id] ON [entradas_c] ([usuario_id]);
CREATE INDEX IF NOT EXISTS [IX_entradas_d_c_id] ON [entradas_d] ([c_id]);
CREATE INDEX IF NOT EXISTS [IX_entradas_d_producto_id] ON [entradas_d] ([producto_id]);
CREATE INDEX IF NOT EXISTS [IX_enviada] ON [venta_c] ([enviada]);
CREATE INDEX IF NOT EXISTS [IX_fecha] ON [venta_c] ([fecha]);
CREATE INDEX IF NOT EXISTS [IX_inv_c_fecha] ON [inv_c] ([fecha]);
CREATE INDEX IF NOT EXISTS [IX_inv_d_c_id] ON [inv_d] ([c_id]);
CREATE INDEX IF NOT EXISTS [IX_inv_d_producto_id] ON [inv_d] ([producto_id]);
CREATE INDEX IF NOT EXISTS [IX_inv_h_c_id] ON [inv_h] ([c_id]);
CREATE INDEX IF NOT EXISTS [IX_inv_h_producto_id] ON [inv_h] ([producto_id]);
CREATE INDEX IF NOT EXISTS [IX_inv_producto_id] ON [inv] ([producto_id]);
CREATE INDEX IF NOT EXISTS [IX_producto_id] ON [venta_d] ([producto_id]);
CREATE INDEX IF NOT EXISTS [IX_responsable] ON [fondos] ([responsable]);
CREATE INDEX IF NOT EXISTS [IX_salidas_c_fecha] ON [salidas_c] ([fecha]);
CREATE INDEX IF NOT EXISTS [IX_salidas_c_folio] ON [salidas_c] ([folio]);
CREATE INDEX IF NOT EXISTS [IX_salidas_c_tipo_id] ON [salidas_c] ([tipo_id]);
CREATE INDEX IF NOT EXISTS [IX_salidas_c_usuario_id] ON [salidas_c] ([usuario_id]);
CREATE INDEX IF NOT EXISTS [IX_salidas_d_c_id] ON [salidas_d] ([c_id]);
CREATE INDEX IF NOT EXISTS [IX_salidas_d_producto_id] ON [salidas_d] ([producto_id]);
CREATE INDEX IF NOT EXISTS [IX_salidas_t_producto_id] ON [salidas_t] ([producto_id]);
CREATE INDEX IF NOT EXISTS [IX_tipo_salida_tipo] ON [tipo_salida] ([tipo]);
