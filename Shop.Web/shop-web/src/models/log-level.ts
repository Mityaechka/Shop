
export enum LogLevel {
    Info,
    Warning,
    Error
}
export namespace LogLevel {
    export function toString(level: LogLevel): string {
        switch (level) {
            case 0: return "Информация";
            case 1: return "Предупреждение";
            case 2: return "Ошибка";
        }
        return "";
    }
}