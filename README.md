# Communication Methods Table

| **Method**              | **Type**            | **Suitable For**                                                                              |
|-------------------------|---------------------|---------------------------------------------------------------------------------------------|
| **Named Pipes**         | IPC                | Real-time communication between local processes. Efficient for small, bidirectional data exchange. |
| **Sockets**             | Network/IPC        | Communication on the same or different machines. Good for scalable, network-based messaging. |
| **WebSockets**          | Network/IPC        | Real-time, bidirectional communication. Commonly used in web apps for interactive data sharing. |
| **Memory-Mapped Files** | IPC                | Ultra-fast data sharing via shared memory. Ideal for performance-critical local processes.  |
| **File-Based Communication**| Disk I/O       | Simple, persistent data exchange. Good for asynchronous communication with minimal setup.   |
| **Message Queues**      | Messaging Middleware | Reliable, asynchronous message delivery. Great for decoupled systems or multi-step workflows. |
| **HTTP REST APIs**      | Network            | Exchanging structured data (e.g., JSON). Good for integration with web-based systems.       |
| **SignalR**             | Framework          | Real-time updates in .NET apps (e.g., chat apps). Simplifies server-to-client communication. |
| **gRPC**                | RPC Framework      | High-performance, cross-language calls. Ideal for distributed microservices architecture.   |
| **Event-Driven Messaging**| Middleware       | Asynchronous communication via events. Good for decoupled, event-driven architectures.      |
| **Command-Line Arguments**| IPC (Process)    | Passing startup configuration or data to another process. Best for simple, one-time use.    |
| **Shared Database**     | Database           | Exchanging data via a common storage point. Good for persistence or multi-process workflows. |
| **Shared Memory**       | IPC                | High-speed communication via direct memory access. Ideal for low-latency, high-performance needs. |
| **REST/SOAP over Localhost**| Network        | Local communication using web service protocols. Useful for standardized, extensible APIs.  |
| **WCF**                 | Framework          | Building service-oriented apps with multiple transport options (e.g., HTTP, TCP, pipes). Great for enterprise solutions. |
| **EventWaitHandle/Mutex**| IPC (Sync Primitive)| Signaling or coordinating between processes. Suitable for simple notification-based messaging. |
| **ZMQ (ZeroMQ)**        | Messaging Library  | Lightweight library for asynchronous messaging. Best for scalable, high-performance apps.   |



# Heimdal Homework

This repository contains a C# solution for two main functionalities:


## 1. Clock Angle Calculation
This part of the solution calculates the angle between the hour and minute hands of a clock based on user input.

### Key Components:
- **ClockAngleService**: A service that computes the angle between the clock's hands.
- **Input/Output**: The user provides the hour and minute, and the program outputs the calculated angle in degrees.



## 2. Shapes Solution
This part of the solution focuses on creating and manipulating geometrical shapes (Circle and Rectangle).

### Key Components:
- Generates a collection of shapes (Circle and Rectangle) with specific rules:
  Shapes are randomly selected.
  Each shape's perimeter matches its position in the collection (e.g., shape at index 2 has a perimeter of 3).
- Calculates the total sum of circle perimeters in the collection.