# RestroManager

## Descripción del sistema
RestroManager es un sistema web diseñado específicamente para mejorar el proceso de gestión de pedidos en los restaurantes de Medellín. Esta plataforma digital no solo simplifica la e| X |periencia de pedido para los clientes permitiéndoles e| X |plorar un menú interactivo y detallado de los productos, también, ofrece una solución integral para la administración del restaurante. A través del aplicativo web, los usuarios pueden sumergirse en descripciones vívidas de los productos, personalizar sus pedidos con observaciones específicas, y compartir su opinión y puntuación sobre la e| X |periencia gastronómica, todo desde la comodidad de su dispositivo.
Por otro lado, el sistema está equipado con funcionalidades que le permitirán al administrador del restaurante, el manejo eficiente del inventario, la capacidad de actualizar y añadir nuevos platos al menú con facilidad, la organización de las categorías de los productos de forma intuitiva, y el monitoreo del balance mensual en función de los gastos e ingresos. Una característica distintiva de RestroManager es su integración directa con el equipo de cocina, permitiendo a los chefs acceder a los detalles de los pedidos y observaciones de los clientes en tiempo real, asegurando así una comunicación fluida y una preparación de los productos precisa y personalizada.

## Funcionalidad Básica
Para describir las funcionalidades de la aplicación nos centraremos en tres componentes fundamentales el _**sistema de gestión de pedidos**_, el _**sistema administrativo**_ y el _**componente de monitoreo y análisis de datos**_.

El _**sistema de gestión de pedidos**_ cuenta con una interfaz gráfica de usuario amigable y fácil de navegar, donde los productos están categorizados de forma clara y ordenada. En ella los usuarios pueden buscar productos específicos por medio de una función de búsqueda que incluye filtros por precio, popularidad y reseñas. Cuando el usuario selecciona el producto de interés puede observar detalles adicionales como descripciones, ingredientes, fotos y reseñas de otros clientes, a su vez cuando el usuario agrega el producto al carrito de compras tiene la opción de agregar comentarios adicionales con los cuales puede personalizar su pedido.
Continuando con la gestión de pedidos es fundamental mencionar la interfaz gráfica que se visualiza en el área de la cocina la cual permite a los cocineros gestionar los pedidos que se tienen en la cola de servicio, inicialmente los pedidos ingresarán en estado Pendiente luego, cuando los cocineros validan los detalles de la orden mediante un botón estos pasan a estar en estado En cocción y finalmente cuando el pedido es finalizado por el área de cocina se establece Camino a la mesa.

En segundo lugar, el _**sistema administrativo**_ presenta vistas en las cuales los administradores del restaurante pueden agregar, editar y eliminar productos, y categorías, en el caso de los productos se debe ingresar un apro| X |imado de la cantidad, e| X |presada en porciones, de cada ingrediente que requiere la preparación del alimento y de igual manera se establece un apro| X |imado de los gastos asociados a la producción de cada porción del alimento. A su vez, se cuenta con una interfaz gráfica que le permite gestionar el inventario del proceso, esta gestión está compuesta de editar, actualizar o agregar la materia prima necesaria para la preparación de los alimentos y de registrar los ingresos de estos insumos.

Nota: internamente el sistema calculará el inventario actual de cada materia prima o ingrediente registrado en el aplicativo mediante el cruce de datos entre los productos vendidos y la cantidad de cada ingrediente que se utiliza en el producto. Es normal que se presenten diferencias en el inventario actual registrado en el sistema y el real, sin embargo, esta información puede ser de utilidad, ya que una inconsistencia muy grande podría indicar que se están sobredimensionando los platillos en el área de la cocina o que se están desperdiciando ingredientes en el proceso. 

Finalmente, los usuarios administradores pueden ingresar al _**componente de monitoreo y análisis de datos**_ en el cual se encuentra un conjunto de reportes que son de importancia para la toma de decisiones estratégicas del negocio, estos se presentan en los siguientes menús:   
•	Reporte de intención de los comensales, el cual consta de estadísticas que determinan los principales productos más demandados por los comensales en cada día de la semana y los productos con mejor calificación según los datos de puntuación de los clientes a la oferta gastronómica del restaurante.  
•	Reporte de capacidad requerida, el reporte cuenta con gráficas que permiten conocer la cantidad de pedidos que se atendieron en determinado periodo de tiempo incluyendo análisis diarios, semanales o mensuales, los datos se enfocan en mostrarle al usuario los días donde la afluencia de clientes es menor o mayor, lo que permite que los administradores del restaurante tomen decisiones rápidas acerca de la cantidad de personal requerida en determinado día.   
•	Reporte de balance de ingresos y gastos, finalmente este menú genera el balance de ingresos y gastos que se obtiene en un lapso de operación; es importante indicar que estos datos dependen de la información que los administradores del comercio ingresen en RestroManager, ya que es responsabilidad del usuario registrar los costos operativos que genera cada producto que es negociado.

## Características Adicionales
•	**Sugerencias Culinarias Personalizadas**: Utilizando el historial de pedidos del cliente, RestroManager realiza un análisis para ofrecer recomendaciones de productos que podrían gustarles, basándose en sus preferencias previas y tendencias de consumo. Esta funcionalidad enriquece la e| X |periencia del usuario al descubrir nuevos sabores y platos favoritos.  
•	**Libro de Sabores**: Similar a las listas de deseos, esta función permite a los usuarios guardar sus productos favoritos o aquellos que desean probar en futuras visitas. Facilita a los comensales la planificación de sus comidas y les asegura una e| X |periencia culinaria personalizada y satisfactoria.  
•	**Promociones E| X |clusivas para Usuarios Registrados**: Para aquellos clientes que forman parte de nuestra comunidad, RestroManager ofrece promociones especiales adaptadas a sus gustos y patrones de consumo. Al iniciar sesión, los usuarios tendrán acceso a descuentos, ofertas y beneficios diseñados para mejorar su e| X |periencia y fidelizar su relación con el restaurante.  
•	**Ajuste de reporte de balance de ingresos y gastos**: Teniendo en cuenta que los ingresos y gastos de los restaurantes no solo dependen del proceso específico de la venta de productos el sistema administrativo cuenta con un menú que permite ingresar diversos tipos de ingresos y gastos, los cuales también pueden ser parametrizables.

## Beneficios para los Negocios
RestroManager redefine el entorno de la hospitalidad culinaria al proporcionar a los establecimientos una herramienta versátil que supera los límites del servicio convencional. Optimiza la gestión de menús, facilita un control eficiente de pedidos y mejora la interacción con los clientes. Mediante el análisis detallado de datos, los negocios gastronómicos pueden descifrar las preferencias de sus clientes con precisión, ajustando su oferta y tácticas de marketing para resonar mejor con las demandas del mercado.
## Conclusión
En la era digital en la que vivimos, RestroManager emerge como una solución vanguardista para el sector del área culinaria, marcando un estilo de atención en el que los restaurantes conectan con su clientela. Al fusionar tecnologías actuales con una interfaz intuitiva y segura, este sistema no solo mejora la e| X |periencia de pedido para los consumidores, sino que también equipa a los negocios gastronómicos con herramientas para mejorar sus operaciones, entender mejor a sus clientes y optimizar su oferta culinaria.

La implementación de RestroManager en Medellín representa un paso adelante hacia la transformación digital de los restaurantes, especialmente los categorizados como microempresas y pequeñas empresas, permitiéndoles no solo sobrevivir en un mercado competitivo, sino prosperar. Adaptándose a las tendencias y a las e| X |pectativas cambiantes de los consumidores, RestroManager facilita una cone| X |ión profunda y significativa entre los restaurantes y sus clientes, promoviendo la fidelización y una cultura con e| X |celencia en el servicio.


# Matriz de funcionalidades

| Funcionalidad | Administrador | Cocinero |	Cliente | Anónimo |
| ----- | ----- | ----- | ----- | ----- |
| Ingresar al sistema con email y contraseña | X |	X |  X  |   | 
| Editar datos de usuario (incluyendo foto de perfil)	| X | X | X | |	
| Cambiar contraseña	| X | X | X | |	
| Recuperar contraseña, si el usuario olvida la contraseña se le enviará un correo con un token para poder recuperar contraseña.	| X | X | X | |  	
| Administrar usuarios, el decir podrá ver todos los usuarios del sistema y crear nuevos administradores	| X | | | |			
| Administrar Países, Estados y Departamentos	| X | | | |			
| Confirmar la cuenta con un email, cuando un usuario se dé de alta, le enviaremos un correo para confirmar su cuenta.	| X | X | X | |	
| Administrar categorías de los platos o productos, es decir, crear, modificar y borrar categorías.	| X | X | |	|	
| Administrar productos, es decir, crear, modificar y borrar producto. Donde un producto puede tener varias categorías, imágenes e ingredientes.	| X | X | | |		
| Administrar ingredientes, es decir, crear, modificar y borrar ingredientes. Cada ingrediente debe tener asociado un costo de producción y puede tener varias materias primas.	| X | X | | |		
| Administrar inventario de materias primas, es decir, crear, modificar y borrar materias primas. A su vez se puede registrar el ingreso de materias o salida de materias primas del inventario	| X | | | |			
| Administrar cola de servicio, es decir modificar el estado de los pedidos presentes en la cola de servicio. Los pedidos pueden estar en los siguientes estados: Pendiente, en cocción, camino a la mesa y finalizado.	| X | X | | |		
| Ver catálogo de productos. Podrá ver todos los productos disponibles, buscarlos, hacer diferentes filtros.	| X | X | X | X |
| Agregar productos al carro de compras, también podrá modificar el carro de compras.	| X | | X | |	
| Confirmar el pedido.	| X | | X | |	
| Ver el estado del pedido	| X | X | | |	
| Administrar lista de favoritos, es decir, crear o eliminar registros de mi lista de pedidos favoritos.	|	|	| X |	|
| Ingresar al reporte de intensión de los comensales.	| X | | | |			
| Ingresar al reporte de capacidad requerida.	| X | | | |			
| Ingresar al reporte de balances de ingresos y gastos.	| X | | | |			
| Administrar tipos de gastos, es decir, crear, modificar y borrar tipos de gastos.	| X | | | |			
| Administrar tipos de ingresos, es decir, crear, modificar y borrar tipos de ingresos.	| X | | | |			
| Administrar ingresos, es decir, crear y eliminar ingresos. | X | | | |			
| Administrar gastos, es decir, crear, modificar y borrar gastos| X | | | |

# Diagrama de entidad relación

![Diagrama de entidad relación de restromanager](/Images/ERDrestromanager.png)