export interface ErrorResultModel {
    isSuccessStatusCode: boolean
    statusCode: number
    message: string
    date: string
    data: Daum[]
}


export interface Daum {
    propertyName: string
    errorMessage: string
    attemptedValue: string
    customState: any
    severity: number
    errorCode: string
    formattedMessagePlaceholderValues: FormattedMessagePlaceholderValues
}

export interface FormattedMessagePlaceholderValues {
    PropertyName: string
    PropertyValue: string
    PropertyPath: string
}
